import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { user } from '../classes/user';

@Injectable({
  providedIn: 'root'
})
export class LoginService {

  constructor(public http:HttpClient) { }

  currentUser:user=new user()
  userName?:string="אנונימי"
  basisUrl:string="https://localhost:7057/api/"

  getUserByMailAndPassword(mail?:string,password?:string):Observable<user>
  {
    return this.http.get<user>(`${this.basisUrl}User/User/${mail}/${password}`)
  }
  addUser(user:user):Observable<number>{
   return this.http.post<number>(`${this.basisUrl}User/addUser`,user)
  }
  deleteUser(id:number):Observable<boolean>{
  debugger
    return this.http.delete<boolean>(`${this.basisUrl}User/${id}`)
  }

}