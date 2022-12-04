# Name

ToDoList

## Descriptions

It’s education project by Sergey Hinkevich.

## Introduce

This application introduce list of task. User can add, delete, edit tasks and group by category.

## Technology

- Pattern MVC
- Microsoft.AspNetCore.App.Ref\3.1.10
- Microsoft.NETCore.App.Ref\3.1.0
- Microsoft.entityframeworkcore.design\3.1.1
- Microsoft.entityframeworkcore.sqlserver\3.1.1
- Microsoft.entityframeworkcore.tools\3.1.1
- Microsoft.visualstudio.web.codegeneration.design\3.1.5
- Microsoft.NET.Test.Sdk
- xUnit 2.4.1
- Coverlet.collector(3.1.2)
- Moq(4.18.2)

### Instalation

- DownLoad repository [ToDoList.Test](https://github.com/hinkevich/ToDoList.Test.git) from github.com (not obligatory)
- DownLoad repository [ToDoList](https://github.com/hinkevich/ToDoList.git) from gitHub.com
- Open project ToDoList in Microsoft Visual Studio.
- Add **ToDoList.Test** into solution(not obligatory).
- Add reference on **ToDoList.Test** from **ToDoList** if needded
- Open **Package Manager console** and input _dotnet ef database update_ (create DB)
- Run aplication press _CTRL+F5_ or _F5_
- You can publish this project in Microsoft Azure, or other services, or folder.
- If you want to publish this project in folder, you can make it with Microsoft Visual Studio:
- - Find in solution Explorer name this project **ToDoList**.
- - Click right botton of mouse on name this project, after click Publish.
- - Choose folder, after click *Publish*
- - Open selected folder and double-click on *ToDoList.exe*
- - Copy from opened window last adress and input to the browser. (Adress can be: [adressOne](https://localhost:5001) or [adressTwo](https://localhost:5000))

### About ToDoList

## What is ToDoList?

>It’s web aplication, which can keep your task. All task is devided on three groups:  
-My Day  
-Important  
-Planned  
>You can Add, Edit, Delete every task. If you click button **All**, you can see all tasks without sorting. 

### Add, Edit, Delete, Change status of task

>### Add Task
>To add a task, you should select one of the three categories: **My Day**, **Important**, **Planned**.
>after you need click **Add Task**, input information in the form and click **Create**.

>### Edit Task
>You can edit any task. You need to click on the button **Edit**, after that you will see the description of the current task. 
>Input new information and click on the button **Save**

>### Delete Task
>You can delete any task. You need to click on the button **Delete**. *Warning!!!* After deleting you will not be able to return this task.
> You will not receive a task deletion message, the task will be deleted immediately.  

>### Change status of task
>Every task have two status:
>-Complited
>-Uncomplited
>If you have already run *ToDoList*, you can look at two tables. First include Uncomplited task. 
>Second include Сomplited task. You can change status of task to click **Done**(1-st table)
>or **Cancel**(2-nd table)

### About ToDoList.Test
>This project includes tests for HomeController of **ToDoList**. 

### Licensing
>MIT
### Contact
>hinkevich@gmail.com
 
