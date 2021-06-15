import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { EventTarget } from 'ngx-bootstrap/utils/facade/browser';
import { IClient } from 'src/app/shared/models/client';

@Component({
  selector: 'app-single-client',
  templateUrl: './single-client.component.html',
  styleUrls: ['./single-client.component.scss']
})
export class SingleClientComponent implements OnInit {
  @Input() client: IClient;
  @Output() updateClientEvent = new EventEmitter<any>();

  showClientsInfo: number;


  clientForm = new FormGroup({
    userId: new FormControl(0),
    userName: new FormControl(''),
    passwordHash: new FormControl(''),
    email: new FormControl(''),
    firstName: new FormControl(''),
    lastName: new FormControl(''),
    addressId: new FormControl(0),
    addressZipCode: new FormControl(''),
    addressCountry: new FormControl(''),
    addressStreet: new FormControl(''),
    addressCity: new FormControl(''),
    addressBuildingNumber: new FormControl(0),
    dateOfBirth: new FormControl(''),
    roleId: new FormControl(0),
    roleName: new FormControl(''),
  });
  constructor() { }

  ngOnInit(): void {
    console.log(this.client.id);
    this.setDefaults();
  }

  onSubmit( userId?: number, userName?: string, passwordHash?: string, email?: string,
    firstName?: string, lastName?: string, addressId?:number, addressZipCode?: string,
    addressCountry?: string, addressStreet?: number, addressCity?: string,
    addressBuildingNumber?: number, dateOfBirth?: Date, roleId?:number,
    roleName?: string
    ) {
    const body = {
      'Id': userId,
      'userName': userName,
      'passwordHash': passwordHash,
      'email': email,
      'firstName': firstName,
      'lastName': lastName,
      'address': {
        'id': addressId,
        'zipCode': addressZipCode,
        'country': addressCountry,
        'street': addressStreet,
        'city': addressCity,
        'buildingNumber': addressBuildingNumber,
      },
      'dateOfBirth': dateOfBirth,
      'role': {
        'id': roleId,
        'name': roleName
      }
    };
    
    this.updateClientEvent.emit({body, userId});
  }

  setDefaults() {
    this.clientForm.controls.userId.setValue(this.client.id);
    this.clientForm.controls.userName.setValue(this.client.userName);
    this.clientForm.controls.passwordHash.setValue(this.client.passwordHash);
    this.clientForm.controls.email.setValue(this.client.email);
    this.clientForm.controls.firstName.setValue(this.client.firstName);
    this.clientForm.controls.lastName.setValue(this.client.lastName);
    this.clientForm.controls.roleName.setValue(this.client.role.name);
    this.clientForm.controls.addressId.setValue(this.client.addressId);
    this.clientForm.controls.addressZipCode.setValue(this.client.address.zipCode);
    this.clientForm.controls.addressCountry.setValue(this.client.address.country);
    this.clientForm.controls.addressStreet.setValue(this.client.address.street);
    this.clientForm.controls.addressCity.setValue(this.client.address.city);
    this.clientForm.controls.addressBuildingNumber.setValue(this.client.address.buildingNumber);
    this.clientForm.controls.dateOfBirth.setValue(this.client.dateOfBirth);
    this.clientForm.controls.roleId.setValue(this.client.roleId);
    this.clientForm.controls.roleName.setValue(this.client.role.name);
  }

  showClient(id: number) {
    this.showClientsInfo = id;
  }

  closeClientInfo() {
    this.showClientsInfo = null;
  }




}