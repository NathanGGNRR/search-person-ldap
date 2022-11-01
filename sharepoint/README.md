# Users Directory

## Development environment
 - Node 14
 - VS Code
 - Visual Studio 2019

## SMTP Configuration
 In Diiage.Directory.Web/appsettings.json
- Host:						IP address or host name of the SMTP server.
- Port:						SMTP port. Usually 25 or 587
- SenderMail:				Sender mail address
- SenderName:				Sender name
- EnableSsl:				Use Secure Sockets Layer (SSL) if true.
- UseDefaultCredentials:	A boolean value that controls whether the DefaultCredentials are sent with requests.
- Login:					SMTP login
- Password:					SMTP password

## Email templates
Email subject and body teamplates are located in Diiage.Directory.Core/Ressources.resx (EmailSubject / EmailBody)
Theses templates can contain placeholders that will be replaced by actual values (from data object properties)
