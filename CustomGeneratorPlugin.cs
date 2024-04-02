using SampleGeneratorPlugin;
using TechTalk.SpecFlow.Generator.Plugins;
using TechTalk.SpecFlow.Generator.UnitTestConverter;
using TechTalk.SpecFlow.Infrastructure;
using TechTalk.SpecFlow.UnitTestProvider;

[assembly:GeneratorPlugin(typeof(GeneratorPlugin.CustomGeneratorPlugin))]

namespace GeneratorPlugin
{
    public class CustomGeneratorPlugin : IGeneratorPlugin
    {
	    public void Initialize(GeneratorPluginEvents generatorPluginEvents, GeneratorPluginParameters generatorPluginParameters,
		    UnitTestProviderConfiguration unitTestProviderConfiguration)
	    {
		    generatorPluginEvents.RegisterDependencies += RegisterDependencies;
	    }

	    private void RegisterDependencies(object sender, RegisterDependenciesEventArgs eventArgs)
	    {
		    eventArgs.ObjectContainer.RegisterTypeAs<TagDecorator, ITestClassTagDecorator>(TagDecorator.TAG_NAME);
            eventArgs.ObjectContainer.RegisterTypeAs<TagDecorator, ITestMethodTagDecorator>(TagDecorator.TAG_NAME);
        }
    }
}
