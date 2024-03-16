using Contract.Responses;
using MediatR;
using Microsoft.AspNetCore.Http;
using Model;

namespace Business.TrashDetection
{
    public static class TrashDetection
    {
        public record Query(IFormFile imageFile) : IRequest<TrashDetectionResponse>;

        public class Handler : IRequestHandler<Query, TrashDetectionResponse>
        {
            public async Task<TrashDetectionResponse> Handle(Query request, CancellationToken cancellationToken)
            {
                using var memoryStream = new MemoryStream();
                await request.imageFile.CopyToAsync(memoryStream, cancellationToken);

                var imageBytes = memoryStream.ToArray();
                
                Trashman.ModelInput inputImage = new()
                {
                    ImageSource = imageBytes,
                };

                var result = Trashman.Predict(inputImage);
                var score = result.Score.Max();
                var isTrash = score > 0.55;

                return new()
                {
                    Confidence = score,
                    IsTrash = isTrash,
                    TrashType = isTrash ? result.PredictedLabel : "No trash detected!"
                };
            }
        }
    }
}