
![](logo-blue.png)
## What is entrepreneurchute?

entrepreneurchute is the latest and greatest technology 
to **connect aspiring entrepreneurs and experienced mentors**. 

Entrepreneurs with specific issues or questions can use entrepreneurchute to collaborate with one of our expert mentors who have the skills they are looking for. Entreprenuers can request topics for mentorship in which fellow entreprenuers can join.  Entreprenuers can then share their experience and recommendation by rating the mentor.

Mentors can collaborate with entrepreneurs to gain a fresh perspective and 
new ideas. They can also discover startup businesses to partner with and gain prestige.

### :grey_question: That's interesting and all, but what's in it for a mentor like me?
- **Prestige** Mentors get an opportunity to work with people who are searching for their help. They will get a chance to share their experience and be rated based on that expierience.
- **Networking** Mentors will get a chance to work with people with similar interests and expand their brand.
- **Profit** Mentors can offer their services for a fee in any way they would like. Entrepreneurchute simply connects the two parties together!
## :open_mouth::open_mouth::open_mouth: That's amazing! but how do I use it?
Easy! just go to this link [**and try it yourself**](https://psu-codeathon.azurewebsites.net/)  
If you are a little more tech oriented, [**You can view our open api here**](https://psu-codeathon.azurewebsites.net/swagger)
## :camera: Examples and Screenshots

# :electric_plug: Installation
This is information for developers for building and running the app from source.
## Libraries Used
- Vue
- Swagger
- Asp.Net Core
- Entity Framework Core

## Useful Scripts

All of the below scripts can be executed in the terminal of your choice (PowerShell/Cmd on windows, Terminal on mac). 
They must be executed from the "Source" folder, where the .Net Core project/node package files are located.

__Front-end:__

* `npm install` - installs any missing npm dependencies. 
When in doubt, run this before any other front-end commands. If you get any errors with the other below commands, try running this first as well.

* `npm run dev` - compiles vue components into wwwroot/dist/app.css and wwroot/dist/app.js files
in development mode - non minified and more error information avaialble. 

* `npm run build` - compiles vue components into same files as above but in production mode - 
minified and with less error info available

* `npm run watch` - compiles vue components into same files as above in watch mode - whenever changes are made 
to the vue components and saved, files get recompiled.


__Back-end:__

* `dotnet run` - runs the backend ASP.Net Core app. This is handiest to use when you're working in VS Code on a mac. Running this will give you a url to browse to to view the running app.

* `dotnet ef migrations add "MigrationName"` - creates a new entity framework code first migration

* `dotnet ef database update` - applies any unapplied migrations to the database

* `dotnet ef migrations remove` - removes the most recent migration, as long as it has not been appleid to the database

