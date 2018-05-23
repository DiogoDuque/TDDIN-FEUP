===== (Relevant) Folder Hierarchy Explained =====

.
├── Backend/                            # folder containing the Visual Studio solution for the backend
└── Frontend/
	├── Department GUI/             # folder containing the NPM project for the Department GUI
	├── Solver GUI/                 # folder containing the NPM project for the Solver GUI
	└── Web/                        # folder containing the NPM project for the Web Application



===== Setup =====


=== Visual Studio ===

1. Install Visual Studio.
2. Open Visual Studio in administrator mode.
3. Import project.
4. Import NuGet packages. (NOTE: make sure you have an Internet connection on this step, as it may prevent installation of relevant packages)
5. Run the Server project.


=== NPM Interfaces ===

NOTE: Even though some interfaces run a GUI and others a Web App, they all follow the same instructions. As such, the below instructions are valid for each of the 3 "Frontend" modules.

1. Install NodeJS (which comes with NPM, the command we need to )
1. Open the terminal/bash and go to the root folder of the module you want to execute ("Department GUI", "Solver GUI" or "Web").
2. Run "npm install". (NOTE: make sure you have an Internet connection on this step, as it may prevent installation of relevant packages)
3. Run "npm start".



===== Other Notes =====

If at any given moment, in one of the GUI applications, you want to 'reload' the application (for example, for seeing an updated state of the database), you can do so by pressing CTRL+R, and it will start as new.
