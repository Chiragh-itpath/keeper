import type { IProject } from "@/Models/ProjectModel";
import { http } from "@/GlobalConfig/ApiClient";

export async function Insert(Project: IProject): Promise<any> {
    try {
        const response = await http.post('/Project', Project)
        console.log(response);
        return response;
    }
    catch (e) {
        console.log(e);
        return e;
    }
}
export async function GetById(ProjectId: string): Promise<any> {
    try {
        const response = await http.get(`/Project/${ProjectId}`)
        console.log(response);
        return response;
    }
    catch (e) {
        console.log(e);
        return e;
    }
}
export async function GetAll(UserId: string): Promise<any> {
    try {
        const response = await http.get(`/Project/${UserId}`)
        console.log(response);
        return response;
    }
    catch (e) {
        console.log(e);
        return e;
    }
}
export async function Delete(ProjectId: string): Promise<any> {
    try {
        const response = await http.delete(`/Project/${ProjectId}`)
        console.log(response);
        return response;
    }
    catch (e) {
        console.log(e);
        return e;
    }
}
export async function Update(Project: IProject): Promise<any> {
    try {
        const response = await http.put('/Project', Project)
        console.log(response);
        return response;
    }
    catch (e) {
        console.log(e);
        return e;
    }
}
