import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';

@Component({
  selector: 'app-add-client',
  templateUrl: './add-client.component.html',
  styleUrls: ['./add-client.component.scss']
})
export class AddClientComponent implements OnInit {
  @Output() addUserEvent = new EventEmitter<any>();

    clientForm = new FormGroup({
    userName: new FormControl(''),
    firstName: new FormControl(''),
    lastName: new FormControl(''),
    password: new FormControl(''),
    confirmPassword: new FormControl(''),
    email: new FormControl(''),
    dateOfBirth: new FormControl(''),
    roleId: new FormControl(1),
    addressBuildingNumber: new FormControl(0),
    addressStreet: new FormControl(''),
    addressCountry: new FormControl(''),
    addressZipCode: new FormControl(''),
    addressCity: new FormControl(''),
  });

  constructor() { }

  ngOnInit(): void {
  }

  onSubmit(
    userName?: string,
    password?: string, 
    confirmPassword?: string,
    email?: string, 
    addressCountry?: string,
    addressZipCode?: string, 
    addressCity?: string,
    addressStreet?: string, 
    addressBuildingNumber?: number, 
    firstName?: string, 
    lastName?: string, 
    dateOfBirth?: Date, 
    roleId?: number, 
) {
    const body = {
      'UserName': userName,
      'RoleId': roleId,
      'FirstName': firstName,
      'LastName': lastName,
      'Country': addressCountry, 
      'ZipCode': addressZipCode,
      'City': addressCity,
      'Street': addressStreet,
      'BuildingNumber': addressBuildingNumber,
      'Password': password,
      'ConfirmPassword': confirmPassword,
      'DateOfBirth': dateOfBirth,
      'Email': email,
    };
    
    this.addUserEvent.emit(body);
  }





}
