*********************************
*********************************								
*********************************								
********  READ ME       *********			
*********************************								
*********************************							
*********************************
//!!!!!// If you are here just for the USERNAME & PASSWORD scroll all the way to the bottom or
simply register a new user and start exploring my mini gallery website.


Hello reader. This readme file is seperated into three sections:
• Project Description
	• Contains general information about the project requirements and what has been achieved
• How to Run
	• Contains information about how to run
• Testing
• Username & Password



Sections are divided by a title covered in forwardslashes. 
This readme file was written in sublime 2. 

Source code can also be found on  https://github.com/Spiderixius/IIT_2nd_Assignment

All external source codes used are linked to in their appropriate usage areas, as a comment. Most of the website was
created using the existing code as inspiration.


//////////////////////////////////
//	Project Description 	//
//////////////////////////////////

This project is based on the required features as shown below.

ASP.NET MVC 6 EF 7, rc-1 was used in developing this mini gallery website.

Required features:
• Login system
• The password should be stored security
• Upload, store, delete, and display images with titles
• Add, remove, and edit users
• Images should only be available to logged in users
• At least be one ajax call in the application
• The site should be protected against XSS and SQL injection

What has been completed:

• Login system/Register System (Used the standard login/register system)
	• When you run the webpage, unless you are logged in, you will not be able to view the content of User List, 
	  Gallery or Upload Image. However, the not logged in user will be able to view Home, About and Contact.
• The password should be stored security
	• It is stored securely using password_hash.
• Upload, store, delete, and display images with titles
	• Yes, this is possible, is it pretty? Well beauty is in the eye of the beholder. 
• Add, remove, and edit users
	• Also done. You can add remove or edit the users. The currently user can only edit themselves. 
• Images should only be available to logged in users
	• Yes, I have implemented session control, via [Authorize].
• At least be one ajax call in the application
	• My delete user function is an ajax call.
• The site should be protected against XSS and SQL injection
	• Yes, I tried hacking it, failed :( 

Extra feature:
• Users List of all available users. 
• Responsive design for the gallery.


//////////////////////////////////
//		How to Run	//
//////////////////////////////////

Build and run in Visual Studio. Don't forget to use dnx to update the database. Otherwise when you try
to register it will tell you to apply migrations which worked for me but I have read that it is not always
that it works.

Also the database file is also provided with the name: 
aspnet5-IIT_2nd_Assignment_admur13-f4a042b8-986b-4a62-bd7a-a2c918e03be5


//////////////////////////////////
//	 Testing		//
//////////////////////////////////

Website was tested in Chrome, Chromium, Firefox. 

//////////////////////////////////
//	 Username & Password	//
//////////////////////////////////

Username: admur13@gmail.com
Password: 53938/Account/Register
