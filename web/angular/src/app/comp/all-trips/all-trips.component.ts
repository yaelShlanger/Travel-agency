import { Time } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { trip } from 'src/app/classes/trip';
import { tripType } from 'src/app/classes/tripType';
import { TripService } from 'src/app/services/tripService.service';
import { DomSanitizer } from '@angular/platform-browser';
import { HomeService } from 'src/app/services/home.service';

@Component({
  selector: 'app-all-trips',
  templateUrl: './all-trips.component.html',
  styleUrls: ['./all-trips.component.css']
})
export class AllTripsComponent implements OnInit {

  constructor(public sh:HomeService,public sa:TripService,public r:Router,private sanitizer: DomSanitizer) { }
  
  all:Array<trip>=new Array<trip>();
  newAll:Array<trip>=new Array<trip>();
  allTypes:Array<tripType>=new Array<tripType>();
  selectedItem: any;
  today:Date=new Date()
  tripImageUrl: string=""; // Variable to store the image URL
  
  ngOnInit(): void {
    this.sh.homePage=true
    this.sa.cameFrom="all trips"
    debugger
    this.sa.getAllTrips().subscribe(
      succ=>{
          if(succ!=null){
          this.all=succ;
          this.newAll=succ;
     
          //  this.tripImageUrl = this.trip.imageUrl;
        }
        this.sa.getAllTripsType().subscribe(
        succ=>{
          if(succ!=null){
            this.allTypes=succ;
        }},
        err=>{
            alert("boom")
        }
      )}, 
      err=>{
        debugger
        alert("err")
      }
    )
    }
//problem with url
getSafeUrl(url: string) {
  return this.sanitizer.bypassSecurityTrustResourceUrl(url);
}

    onSelectionChange() {
     this.newAll=new Array<trip>()
     if(this.selectedItem!="הכל"){
      for(let i in this.all){
           if(this.all[i].typeName==this.selectedItem){
            this.newAll.push(this.all[i]);
           }
      }}
      else{
        this.newAll=this.all
      }

    }
    sendWithDetails(i:trip) {
      debugger
        this.sa.currentTrip=i
        this.r.navigate([`./details`])
     }
     jump(){
     
    }

    parseDate(dateString: Date): Date | null {
      if (dateString) {
        return new Date(dateString);
      }
      return null;
    }

    }


    // import { Component } from '@angular/core';
 
// @Component({
//   selector: 'demo-propeller-card',
//   templateUrl: './all-trips.component.html'
// })
// export class DemoPropellerCardComponent {}