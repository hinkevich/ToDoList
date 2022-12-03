# Name

ToDoList

## Descriptions

It’s education project by Sergey Hinkevich.

## Introduce

This application introduce list of task. User can add, delete, edit tasks and groups by category.

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
- Add **ToDoList.Test** into solution.
- Add reference on **ToDoList.Test** from **ToDoList** if needded
- Open **Package Manager console** and input _dotnet ef database update_ (create DB)
- Run aplication press _CTRL+F5_ or _F5_

## How use ToDoList

### Add, Edit, Delete, Change status of task

>### Add Task
>To add a task, you should select one of the three categories: **My Day**, **Important**, **Planned**.
>after you need click **Add Task**, input information in the form and click **Create**.

>### Edit Task
>You can edit any task. You need to click button **Edit**, after You look describe>of particular task. 
>Input new information and click button **Save**

>### Delete Task
>You can delete any task. You need to click button **Delete**. *Warning!!!* After you can't return this task.
> You don`t get question about your wish to save this task.  

>### Change status of task
>Every task have two status:
>-Comlited
>-Uncomplited
>If you already ran *ToDoList*, You can look two tables. First include Uncomplited task. 
>Second include complited task.If you click 


