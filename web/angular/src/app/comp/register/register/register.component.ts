import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { user } from 'src/app/classes/user';
import { HomeService } from 'src/app/services/home.service';
import { LoginService } from 'src/app/services/login.service';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

  constructor(public sh:HomeService,public sr:LoginService,public route:Router) { }

  ngOnInit(): void {
    this.sh.homePage=true
  }
  newUser: user = new user()
  add(){
    this.sr.addUser(this.newUser).subscribe(
      succ=>{  
        debugger
        this.sr.userName=this.newUser.firstName;
          Swal.fire(`! נוסף בהצלחה ${this.newUser.firstName}`, "תודה", 'success');

          this.route.navigate([`./allTrips`])      
         },  
      err=>{
        alert("בעיה")}
    )
  }
}
