https://www.codewithc.com/how-to-setup-opengl-glut-in-codeblocks/

Steps to Setup OpenGL (GLUT) in CodeBlocks:
Step – 1

Download GLUT Library and unzip the file.
Step – 2

Open include folder from the downloaded file
Copy the glut.h file and paste to the folder “C:\Program Files\CodeBlocks\MinGW\include\GL“.
Open lib folder from downloaded file.
Copy all files and paste to the folder “C:\Program Files\CodeBlocks\MinGW\lib“.
Open bin folder from the downloaded file.
Copy the glut.dll file and paste to the folder “C:\Windows\System32“.
Step – 3

Open Code::Blocks. You’ll see the window as shown below.
Click on Create a new project link.
How to set up OpenGL (GLUT) in CodeBlocks
Step – 4

Click on GLUT project, then click Go.
How to set up OpenGL (GLUT) in CodeBlocks

Enter the title name of the project, and give path to save the project.
The project file is created by default from the title name of the project.
How to set up OpenGL (GLUT) in CodeBlocks

Click Next.
Step – 5

For GLUT location, give the path “C:\Program Files\CodeBlocks\MinGW“
How to set up OpenGL (GLUT) in CodeBlocks

Click Next.
How to set up OpenGL (GLUT) in CodeBlocks

Click Finish.
Step – 6

As of this step, a project is finally created, and you’ll get a default main.cpp file.
Don’t forget to include the header file –  “#include<windows.h>“, otherwise you’ll get error.
How to set up OpenGL (GLUT) in CodeBlocks

Build and Run, and you’ll see a window as shown below.
How to set up OpenGL (GLUT) in CodeBlocks

If you see the output of your program as shown above, you’ve properly setup OpenGL (GLUT) in CodeBlocks, and successfully created a project. Already aforementioned – GLUT makes learning OpenGL easier, and as a cross-platform it creates a much portable code between operating systems.

If you’re just getting started with programming in OpenGL, using GLUT is the best choice. It takes only a few lines of code, and does not require in-depth knowledge of operating system.

You can check out my earlier post which was about setting up graphics.h in CodeBlocks. You can also find “How to set up” articles regarding SDL, wxWidgets, GLFW in CodeBlocks, and more in this site. I hope this post helped you to easily setup OpenGL (GLUT) in CodeBlocks. If you encounter any problems, do mention them in the comments section below.
