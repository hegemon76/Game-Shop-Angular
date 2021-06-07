import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { AccountService } from '../_services/account.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent implements OnInit {
  form:FormGroup;

  constructor(
    private formBuilder: FormBuilder,
    private accountService:AccountService
    ) { }

  ngOnInit(): void {
    this.form=this.formBuilder.group({
        userName:'',
        firstName:'',
        lastName: '',
        password:'',
        confirmPassword:'',
        email:'',
        dateOfBirth:Date,
        zipCode:'',
        country:'',
        buildingNumber:'',
        street: '',
        city: '',
    });
  }

 register():void{
   console.log(this.form.getRawValue())
  this.accountService.register(this.form.getRawValue());
 }
 

}
