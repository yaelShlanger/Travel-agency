import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { orderTicket } from 'src/app/classes/orderTicket';
import { trip } from 'src/app/classes/trip';
import { tripType } from 'src/app/classes/tripType';
import { user } from 'src/app/classes/user';
import { HomeService } from 'src/app/services/home.service';
import { LoginService } from 'src/app/services/login.service';
import { TripService } from 'src/app/services/tripService.service';
import { UserService } from 'src/app/services/user.service';
import Swal from 'sweetalert2';

@Component({
  selector: 'private-trips',
  templateUrl: './private.component.html',
  styleUrls: ['./private.component.css']
})
export class privateComponent implements OnInit {
  constructor(public sh:HomeService, public sl: LoginService, public r: Router, public su: UserService,public st:TripService) { }

  selectedItem: string = "";
  selectedPriceItem:number=0;
  selectedTimeItem:number=0;
  Timeselect:string="";
  newallTrips: Array<trip> = new Array<trip>();
  allTripType: Array<tripType> = new Array<tripType>();
  openEdit: boolean = false;
  openTrips: boolean = true;
  Trips: Array<trip> = new Array<trip>();
  updateUser: user = new user()
  display: boolean = false
  displayTrips: boolean = false
  myTrips:Array<trip> = new Array
  today: Date = new Date();
  allOrders:Array<orderTicket>=new Array<orderTicket>;
  myOrder:orderTicket|undefined=new orderTicket()
  showButton:boolean=false; 


  ngOnInit(): void {
    this.showMyTrips()
    this.sh.homePage=true
  }

  showButtons(){
    this.showButton=!this.showButton
  }

  show() {
    this.display = !this.display
  }

  update() {
    this.su.updateUser(this.sl.currentUser).subscribe(
      succ => {
        Swal.fire(`! התעדכן בהצלחה `, "תודה", 'success');
      },
      err => {
        Swal.fire(`! הפרטים לא התעדכנו  `, "🙁", 'error');
      }
    )
  }
    //פונקציה לפתיחת טופס פרטים
    toEdit() {
      debugger
      this.openTrips = false;
      this.openEdit = !this.openEdit
    }

  delete() {
    debugger
    this.sl.deleteUser(this.sl.currentUser.id!).subscribe(
      succ => {
        debugger
        if (succ == true) {
          Swal.fire('המשתמש נמחק בהצלחה', '', 'info')
        }
        else {
          debugger
          Swal.fire('לא ניתן למחוק משתמש זה', 'ישנם הזמנות לטיולים', 'info')
        }
      },
      err => {
        debugger
        Swal.fire('המחיקה נכשלה', '', 'error')
      }
    )
  }
  selectTime(){

  }

  onSelectionChange() {
    this.selectedPriceItem=0;
    this.newallTrips = new Array<trip>();
 
    if (this.selectedItem != "הכל") {

      for (let i in this.Trips) {
        if (this.Trips[i].typeName == this.selectedItem) {
          this.newallTrips.push(this.Trips[i])
        }
      }
    }
    else {
      this.newallTrips = this.Trips
      
    }
  }
  
  onPriceSelectionChange(){
    this.selectedItem="הכל";
    this.newallTrips = new Array<trip>();
    if(this.selectedPriceItem==0)
    this.newallTrips=this.Trips
    else{
    for (let i in this.Trips) {
      if (this.Trips[i].price! < this.selectedPriceItem) {
           this.newallTrips.push(this.Trips[i])
      }
     }
    }
}
  onTimesSelectionChange(){

  }

  showMyTrips() {
    debugger
    this.openEdit = false;
    this.openTrips = true;

    this.st.getAllTripToUser(this.sl.currentUser.id!).subscribe(
      succ => {
        this.Trips = succ;
        this.newallTrips = succ
        //קריאה נוספת לכל סוגי הטיולים
        this.st.getAllTripsType().subscribe(
          suc => {
            this.allTripType = suc
          },
          er => {
            // alert("בעיה בסוגי טיולים")
          })
      },
      err => {
        // alert("בעיה בהצגת כל הטיולים למשתמש"+err.error)
      }
    )
  }
//מחיקת הזמנה לטיול 
  cancel(i:trip){

   this.st.getInviteToTrip(i).subscribe(
    succ=>{
      debugger
     this.allOrders=succ
     this.myOrder= this.allOrders.find(order => order.userId === this.sl.currentUser.id)
     
     
     if(this.myOrder?.id!=null){
     this.st.remove(this.myOrder.id).subscribe(
         succ=>{
          Swal.fire("! טיול נמחק" , "",'success');
          this.showMyTrips()
         },
         err=>{
          Swal.fire(" הזמנה לא נמחקה" , "",'error');
         }
     )
     }
  },

    err=>{
      Swal.fire("כשלון מלכתחילה" , "" ,'error');
    }
   )

  }
  isBig(i:trip){
       return (i.date && i.date.getMilliseconds > this.today.getMilliseconds);

  }

  
  parseDate(dateString: Date): Date | null {
    if (dateString) {
      return new Date(dateString);
    }
    return null;
  }
}
