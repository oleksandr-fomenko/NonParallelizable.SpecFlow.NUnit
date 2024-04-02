using System.CodeDom;
using TechTalk.SpecFlow.Generator;
using TechTalk.SpecFlow.Generator.UnitTestConverter;

namespace SampleGeneratorPlugin
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

        public int Priority { get; }
		public bool RemoveProcessedTags { get; }
		public bool ApplyOtherDecoratorsForProcessedTags { get; }
	}
}
