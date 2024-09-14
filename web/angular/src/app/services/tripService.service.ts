import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { trip } from '../classes/trip';
import { tripType } from '../classes/tripType';
import { orderTicket } from '../classes/orderTicket';

@Injectable({
  providedIn: 'root'
})
export class TripService {

  constructor(public http:HttpClient) {}
 
  currentTrip:trip=new trip()
  basisUrl:string="https://localhost:7057/api/"
  cameFrom:string=""
  getAllTrips():Observable<Array<trip>>
  {
    return this.http.get<Array<trip>>(`https://localhost:7057/api/Trip/AllTrips`)
  }
  getAllTripsType():Observable<Array<tripType>>
  {
    return this.http.get<Array<tripType>>(`https://localhost:7057/api/Trip/TripsType`)
  }
  //הוספת טיול
  addInviteToTrip(o:orderTicket):Observable<number>{
     return this.http.post<number>(`${this.basisUrl}Trip/orderTrip`,o)
  }

  getAllTripToUser(id:number):Observable<Array<trip>>{
     return this.http.get<Array<trip>>(`${this.basisUrl}User/GetAllTripsToUser/${id}`) 
  }

  getInviteToTrip(t:trip):Observable<Array<orderTicket>>{
    return this.http.put<Array<orderTicket>>(`${this.basisUrl}Trip/InviteToTripById`,t) 
 }

 remove(id:number):Observable<boolean>{
  debugger
  return this.http.delete<boolean>(`${this.basisUrl}Trip/order/${id}`)
}
}
