import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { user } from '../classes/user';
import { trip } from '../classes/trip';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(public http:HttpClient) { }
  
  updateUser(user:user):Observable<boolean>
  {
    return this.http.patch<boolean>(`https://localhost:7057/api/User/updateUser`,user)
  }

  getTrips(id:number){
    return this.http.get<Array<trip>>(`https://localhost:7057/api/User/GetAllTripsToUser/${id}`)
  }

  getAllUser(){
    return this.http.get<Array<user>>(`https://localhost:7057/api/User/AllUsers`)
  }
}