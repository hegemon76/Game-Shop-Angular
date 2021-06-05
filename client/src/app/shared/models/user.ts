import { IAddresses } from "./address";
import { IRoles } from "./role";

export interface IUsers {
    id: number;
    firstName: string;
    lastName: string;
    userName: string;
    passwordHash: string;
    email: string;
    dateOfBirth:Date;
    address: IAddresses;
    role:IRoles;
}