import { Time } from "@angular/common";

export class orderTicket{
    constructor(public id?:number, public userId?:number, public fullName?:string, public destination?:string
        ,public dateOfTrip?:Date, public orderTime?:Time , public hours?:number , public tripId?:number, public tickets?:number) {       
    }
    }
