Feature: Access to GitHub

Scenario: Access to GitHub by HTTP is redirect to HTTPS
	When Open URL http://github.com/
	Then Redirect to https://github.com/
