import { environment } from 'src/environments/environment';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ITask } from '../models/task.view-model';

@Injectable({
  providedIn: 'root'
})
export class TaskService {

  readonly baseUrl = environment.api;

  constructor(private httpClient: HttpClient) { }

  add(teamForm: any): Observable<string> {
    const url = this.baseUrl + 'task';

    return this.httpClient.post<string>(url, teamForm);
  }

  get(): Observable<ITask[]> {
    const url = this.baseUrl + 'task';

    return this.httpClient.get<ITask[]>(url);
  }

  changeStatus(id: string, statusId: number): Observable<any> {
    const url = this.baseUrl + 'task/' + id;

    return this.httpClient.post<any>(url, statusId);
  }

  delete(id: string){
    const url = this.baseUrl + 'task/' + id;

    return this.httpClient.delete<any>(url);
  }
}
