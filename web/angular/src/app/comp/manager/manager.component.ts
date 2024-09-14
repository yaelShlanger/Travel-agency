import { Component, OnInit } from '@angular/core';
import { user } from 'src/app/classes/user'
import { HomeService } from 'src/app/services/home.service';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-manager',
  templateUrl: './manager.component.html',
  styleUrls: ['./manager.component.css']
})
export class ManagerComponent implements OnInit {
allUsers:Array<user>=new Array<user>();

  constructor(public sh:HomeService,public su:UserService) { }

ngOnInit(): void {
  this.sh.homePage=true
 this.su.getAllUser().subscribe(
  succ=>{
   this.allUsers=succ
  },
 err=>{
    alert(err.error)
    console.log(err)
  }
 )
}

}
