import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { user } from 'src/app/classes/user';
import { HomeService } from 'src/app/services/home.service';
import { LoginService } from 'src/app/services/login.service';
import Swal from 'sweetalert2';


@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
})
export class LoginComponent implements OnInit {

  constructor(public sh:HomeService,public sl:LoginService,public r:Router) { }

  ngOnInit(): void {
    this.sh.homePage=true
  }

 userNewEdit: user = new user();
//פונקציה הבודקת בעת התחברות האם המשתמש קיים ואם הוא מנהל
 send(){
  debugger
this.sl.getUserByMailAndPassword(this.userNewEdit.mail,this.userNewEdit.password).subscribe(
  succ=>{
    debugger
    if(succ!=null){
      this.sl.currentUser=succ;
      this.sl.userName=this.sl.currentUser.firstName;
      Swal.fire("!התחברת בהצלחה", "בהנאה", 'success'); 
      this.r.navigate([`./allTrips`])  
      }    
      //בדיקת מנהל
      else if(this.userNewEdit.password==localStorage.getItem('managerPassword')&& 
      this.userNewEdit.mail==localStorage.getItem('managerMail')){
        this.sl.userName="מנהל";
        Swal.fire("!מנהל התחברת בהצלחה", "בהנאה", 'success');
        this.r.navigate([`./allTrips`])    
      }     
          
    else{
      this.r.navigate([`./register`])
    }
  },  
  err=>{
    alert("משתמש לא קיים או בעיה בסיסמה")}
)
}
}