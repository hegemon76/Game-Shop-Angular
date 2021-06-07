import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { AccountService } from '../_services/account.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {
  form:FormGroup;

  constructor(
    private formBuilder: FormBuilder,
    private accountService:AccountService
    ) { }

  ngOnInit(): void {
    this.form=this.formBuilder.group({
        userName:'',
        password:'',
    });
  }
login(){
  console.log(this.form.getRawValue())
  this.accountService.login(this.form.getRawValue());
}

}
