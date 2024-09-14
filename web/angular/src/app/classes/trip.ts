import { Time } from "@angular/common";

export class trip{
    constructor(public id?:number,public destination?:string ,public type?:number,public typeName?:string
        ,public needMedic?:boolean,public date?:Date,public departure?:Time
        ,public hours?:number ,public vacancys?:number ,public price?:number ,public img?:string){}
}