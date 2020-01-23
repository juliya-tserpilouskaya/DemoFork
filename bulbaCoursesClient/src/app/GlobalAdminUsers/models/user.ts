import { Role } from './role';

/*export interface User {
  //constructor(
     Id: string;
     Username: string;
     age: number;
    //) {}
}
*/
export interface  User {
  Id: string;
  Username: string;
  PhoneNumber: string;
  Email: string;
  UserRoles: string;
  Lockout: string;
}
