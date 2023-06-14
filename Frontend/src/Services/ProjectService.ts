import type { IProject } from "@/Models/ProjectModel";
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
