import { formatDate } from '@angular/common';
import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
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

  roles = [
    {
      'id': 1,
      'name': 'User'
    },
    {
      'id': 2,
      'name': 'Admin'
    }
  ];

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
    this.setDefaults();
  }

  onSubmit(userId?: number, userName?: string, passwordHash?: string, email?: string,
    firstName?: string, lastName?: string, addressId?: number, addressZipCode?: string,
    addressCountry?: string, addressStreet?: number, addressCity?: string,
    addressBuildingNumber?: number, dateOfBirth?: Date, roleId?: number,
    roleName?: string) {
      
    if (roleName == 'User') {
      roleId = 1;
    }
    if (roleName == 'Admin') {
      roleId = 2;
    }
    const body = {
      'Id': userId,
      'userName': userName,
      'passwordHash': passwordHash,
      'email': email,
      'firstName': firstName,
      'lastName': lastName,
      'addressId': addressId,
      'address': {
        'id': addressId,
        'zipCode': addressZipCode,
        'country': addressCountry,
        'street': addressStreet,
        'city': addressCity,
        'buildingNumber': addressBuildingNumber,
      },
      'dateOfBirth': dateOfBirth,
      'roleId': roleId,
      'role': {
        'id': roleId,
        'name': roleName
      }
    };

    this.updateClientEvent.emit({ body, userId });
  }

  onRoleChange(event: any) {
    console.log(event);
  }
  setDefaults() {
    this.clientForm.controls.userId.setValue(this.client.id);
    this.clientForm.controls.userName.setValue(this.client.userName);
    this.clientForm.controls.passwordHash.setValue(this.client.passwordHash);
    this.clientForm.controls.email.setValue(this.client.email);
    this.clientForm.controls.firstName.setValue(this.client.firstName);
    this.clientForm.controls.lastName.setValue(this.client.lastName);
    this.clientForm.controls.roleName.setValue(this.client.role.name);
    this.clientForm.controls.addressId.setValue(this.client.address.id);
    this.clientForm.controls.addressZipCode.setValue(this.client.address.zipCode);
    this.clientForm.controls.addressCountry.setValue(this.client.address.country);
    this.clientForm.controls.addressStreet.setValue(this.client.address.street);
    this.clientForm.controls.addressCity.setValue(this.client.address.city);
    this.clientForm.controls.addressBuildingNumber.setValue(this.client.address.buildingNumber);
    this.clientForm.controls.dateOfBirth.setValue(this.client.dateOfBirth);
    this.clientForm.controls.roleId.setValue(this.client.role.id);
    this.clientForm.controls.roleName.setValue(this.client.role.name);
  }

  showClient(id: number) {
    this.showClientsInfo = id;
  }

  closeClientInfo() {
    this.showClientsInfo = null;
  }

}