import { Component, OnInit } from '@angular/core';
import { orderTicket } from 'src/app/classes/orderTicket';
import { HomeService } from 'src/app/services/home.service';
import { LoginService } from 'src/app/services/login.service';
import { TripService } from 'src/app/services/tripService.service';
import Swal from 'sweetalert2';

@Component({
  selector: 'details-trips',
  templateUrl: './details.component.html',
  styleUrls: ['./details.component.css']
})
export class detailsComponent implements OnInit {
constructor(public sh:HomeService, public st:TripService,public sl:LoginService ) { }
display:boolean=false  
numVacancy:number=0

ngOnInit(): void {
  this.sh.homePage=true  
}

invite(){
   this.display=!this.display
}

// changeSuffix(img:string){
// img=img.substring()
// }

inviteToTrip(){
  debugger
   let ot:orderTicket=new orderTicket();
   ot.userId=this.sl.currentUser.id
   ot.fullName=this.sl.currentUser.firstName+" "+this.sl.currentUser.lastName
   ot.destination=this.st.currentTrip.destination
   ot.dateOfTrip=this.st.currentTrip.date
   ot.hours=this.st.currentTrip.hours
   ot.tripId=this.st.currentTrip.id
   ot.tickets=this.numVacancy
   this.st.addInviteToTrip(ot).subscribe(
   succ=>{
    Swal.fire("נוסף בהצלחה", succ+"הזמנה:", 'success'); 

   },
   err=>{
    Swal.fire("ההוספה נכשלה ","", 'error'); 

   }
   )
}

}
