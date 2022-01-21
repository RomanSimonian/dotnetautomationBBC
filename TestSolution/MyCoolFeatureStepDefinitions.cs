using TechTalk.SpecFlow;

namespace TestSolution
{
    [Binding]
    public class MyCoolFeatureStepDefinitions
    {
        [When(@"I go to google\.com")]
        public void WhenIGoToGoogle_Com()
        {
            throw new PendingStepException();
        }

        [Then(@"I should be at gooble")]
        public void ThenIShouldBeAtGooble()
        {
            throw new PendingStepException();
        }

        [Then(@"I go to a sp")]
        public void ThenIGoToASp()
        {
            throw new PendingStepException();
        }

        [Then(@"I go to a specific website '([^']*)'")]
        public void ThenIGoToASpecificWebsite(int index)
        {
        }

        [Then(@"I select index <(.*)>")]
        public void ThenISelectIndex(int index)
        {
            throw new PendingStepException();
        }

        [Then(@"I select username '([^']*)'")]
        public void ThenISelectUsername(string username)
        {
            throw new PendingStepException();
        }

    }
}
