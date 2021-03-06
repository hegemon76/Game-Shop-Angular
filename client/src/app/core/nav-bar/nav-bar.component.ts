import { Component, OnInit } from '@angular/core';
import { AccountService } from 'src/app/_services/account.service';

@Component({
  selector: 'app-nav-bar',
  templateUrl: './nav-bar.component.html',
  styleUrls: ['./nav-bar.component.scss']
})
export class NavBarComponent implements OnInit {
  isLogged: boolean = false;
  currentUser: any = null;

  constructor(private accountService: AccountService) { }

  ngOnInit(): void {
    this.getLoggedUser();
  }

  getLoggedUser() {
    this.currentUser = this.accountService.getUser();
    if(this.currentUser != null){
      this.isLogged = true;
      console.log(this.currentUser.userName);
    }
  }
  logout(): void {
    this.accountService.logout();
    window.location.reload();
  }


}

