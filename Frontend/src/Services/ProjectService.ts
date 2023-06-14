import type { IProject } from "@/Models/ProjectModel";
import type {IProjectUpdate} from "@/Models/ProjectUpdateModel"
import axios from "axios";

export async function Insert(): Promise<any> {
    const project: IProject = {
        Title: "Title",
        Description: "Description"
    }
    try {
        const token="eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiJKV1RTZXJ2aWNlQWNjZXNzVG9rZW4iLCJqdGkiOiI1MzM5ZDkzZC1mYTQ0LTQ5NWYtOGY1ZS1lODg1MmJmMzI1YzAiLCJpYXQiOiIxNC0wNi0yMDIzIDA4OjMzOjI3IEFNIiwiSWQiOiIwMTQxNDE1NS03ZTQ1LTQwMmMtOWUwYy0wYTRlYWZiZmFhZTgiLCJleHAiOjE2ODY3MzUxNDcsImlzcyI6IkpXVEF1dGhlbnRpY2F0aW9uU2VydmVyIiwiYXVkIjoiSldUU2VydmljZVBvc3RtYW5DbGllbnQifQ.OQ-ZrOofVjv-rG27P99cVyX1glkMLaZonH0KUD3lLMY"
        const config={headers:{Authorization: `Bearer ${token}`}}
        const response = await axios.post(
            'https://localhost:7134/api/Project',
            project,config
        )
        console.log(response);
        return response;
    }
    catch (e) {
        console.log(e);
        return e;
    }
}

export async function GetById():Promise<any>{
    try{
        const token="eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiJKV1RTZXJ2aWNlQWNjZXNzVG9rZW4iLCJqdGkiOiI1MzM5ZDkzZC1mYTQ0LTQ5NWYtOGY1ZS1lODg1MmJmMzI1YzAiLCJpYXQiOiIxNC0wNi0yMDIzIDA4OjMzOjI3IEFNIiwiSWQiOiIwMTQxNDE1NS03ZTQ1LTQwMmMtOWUwYy0wYTRlYWZiZmFhZTgiLCJleHAiOjE2ODY3MzUxNDcsImlzcyI6IkpXVEF1dGhlbnRpY2F0aW9uU2VydmVyIiwiYXVkIjoiSldUU2VydmljZVBvc3RtYW5DbGllbnQifQ.OQ-ZrOofVjv-rG27P99cVyX1glkMLaZonH0KUD3lLMY"
        const config={headers:{Authorization: `Bearer ${token}`}}
        const response=await axios.get(
            'https://localhost:7134/api/Project/55763296-d8ee-45eb-acae-319481fdf02e',
            config
        )
        console.log(response);
        return response;
    }
    catch (e) {
        console.log(e);
        return e;
    }
}
export async function Delete():Promise<any>{
    try{
        const token="eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiJKV1RTZXJ2aWNlQWNjZXNzVG9rZW4iLCJqdGkiOiJmMTNmNDA4Ny0wOWM5LTQ3NGQtODU1NC0zMzNlZGQxOTUwZDgiLCJpYXQiOiIxNC0wNi0yMDIzIDEwOjE0OjUwIEFNIiwiSWQiOiIwMTQxNDE1NS03ZTQ1LTQwMmMtOWUwYy0wYTRlYWZiZmFhZTgiLCJleHAiOjE2ODY3NDEyMzAsImlzcyI6IkpXVEF1dGhlbnRpY2F0aW9uU2VydmVyIiwiYXVkIjoiSldUU2VydmljZVBvc3RtYW5DbGllbnQifQ.rxmS9x9s8wt1PGPDXgD0LNIwRg44mn1mgYYHJxEtd5U"
        const config={headers:{Authorization: `Bearer ${token}`}}
        const response=await axios.delete(
            'https://localhost:7134/api/Project/55763296-d8ee-45eb-acae-319481fdf02e',
            config
        )
        console.log(response);
        return response;
    }
    catch (e) {
        console.log(e);
        return e;
    }
}
export async function Update():Promise<any>{
    try{
        const project: IProjectUpdate = {
            Id:"c039a43e-dfa8-4fbf-8f77-f02df767c9fb",
            Title: "Title",
            Description: "Description"
        }
        const token="eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiJKV1RTZXJ2aWNlQWNjZXNzVG9rZW4iLCJqdGkiOiJhNjRmYzE3OC01ODMyLTQyNzMtYTY3Zi1jMTc2ODljMmY3NjAiLCJpYXQiOiIxNC0wNi0yMDIzIDExOjAxOjMyIEFNIiwiSWQiOiIwMTQxNDE1NS03ZTQ1LTQwMmMtOWUwYy0wYTRlYWZiZmFhZTgiLCJleHAiOjE2ODY3NDQwMzIsImlzcyI6IkpXVEF1dGhlbnRpY2F0aW9uU2VydmVyIiwiYXVkIjoiSldUU2VydmljZVBvc3RtYW5DbGllbnQifQ.1ftILln5yMoVOUvmkjDdNvyMLZpGbtzQ4SaK61Qdogw"
        const config={headers:{Authorization: `Bearer ${token}`}}
        const response=await axios.put(
            'https://localhost:7134/api/Project',project,
            config
        )
        console.log(response);
        return response;
    }
    catch (e) {
        console.log(e);
        return e;
    }
}
