using System.CodeDom;
using TechTalk.SpecFlow.Generator;
using TechTalk.SpecFlow.Generator.UnitTestConverter;

namespace GeneratorPlugin
{
	public class TagDecorator : ITestMethodTagDecorator, ITestClassTagDecorator
    {
		public static readonly string TAG_NAME = "NonParallelizable";
        private static readonly CodeAttributeDeclaration ATTRIBUTE = new CodeAttributeDeclaration("NUnit.Framework.NonParallelizableAttribute");
        private readonly ITagFilterMatcher _tagFilterMatcher;

		public TagDecorator(ITagFilterMatcher tagFilterMatcher)
		{
			_tagFilterMatcher = tagFilterMatcher;
		}

		public bool CanDecorateFrom(string tagName, TestClassGenerationContext generationContext, CodeMemberMethod testMethod)
		{
            return CanDecorateFrom(tagName);
        }

		public void DecorateFrom(string tagName, TestClassGenerationContext generationContext, CodeMemberMethod testMethod)
		{
			testMethod.CustomAttributes.Add(ATTRIBUTE);
		}

        public bool CanDecorateFrom(string tagName, TestClassGenerationContext generationContext)
        {
			return CanDecorateFrom(tagName);
        }

        public void DecorateFrom(string tagName, TestClassGenerationContext generationContext)
        {
            generationContext.TestClass.CustomAttributes.Add(ATTRIBUTE);
        }

        private bool CanDecorateFrom(string tagName)
        {
            return _tagFilterMatcher.Match(TAG_NAME, tagName);
        }

        int ITestMethodTagDecorator.Priority
        {
            get { return PriorityValues.High; }
        }

        bool ITestMethodTagDecorator.RemoveProcessedTags
        {
            get { return true; }
        }

        bool ITestMethodTagDecorator.ApplyOtherDecoratorsForProcessedTags
        {
            get { return true; }
        }

        int ITestClassTagDecorator.Priority
        {
            get { return PriorityValues.High; }
        }

        bool ITestClassTagDecorator.RemoveProcessedTags
        {
            get { return true; }
        }

        bool ITestClassTagDecorator.ApplyOtherDecoratorsForProcessedTags
        {
            get { return true; }
        }
    }
}
