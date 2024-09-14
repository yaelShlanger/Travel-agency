import { Component, OnInit } from '@angular/core';
import { user } from 'src/app/classes/user';
import { HomeService } from 'src/app/services/home.service';
import { LoginService } from 'src/app/services/login.service';

@Component({
  selector: 'edit-trips',
  templateUrl: './edit.component.html',
  styleUrls: ['./edit.component.css']
})
export class editComponent implements OnInit {
constructor(public sh:HomeService, public sl:LoginService) { }

updateUser:user=new user()
ngOnInit(): void {
  this.updateUser=this.sl.currentUser
  this.sh.homePage=true
}

}
