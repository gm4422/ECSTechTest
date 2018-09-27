Feature: NavigateToSection
	As an job applicant, I need a button so I can get to the next section of the React App 

Scenario: NavigateToSection_Job Applicant click button and navigates to next section
	Given I have the ECS Digital Tech app open
	When I press the render challenge button
	Then I should be taken to the Arrays Challenge section
