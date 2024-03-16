using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.ML;

namespace Model;

public static class ModelRegistration
{
    public static void AddModel(this IServiceCollection services) => 
        services
            .AddPredictionEnginePool<Trashman.ModelInput, Trashman.ModelOutput>().FromFile("..\\Model\\Trashman.mlnet");
}