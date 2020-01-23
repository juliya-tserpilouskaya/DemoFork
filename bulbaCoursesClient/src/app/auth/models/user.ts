export interface User {
  id: string;
  // define user data here
}

export interface PresentationUser extends User {
  name: string;
}
export interface RegisterUser extends User {
  sub: string;
  given_name: string;
  family_name: string;
  preferred_username: string;
}
export interface CustomUser extends User {
  sub: string;
  email: string;
  password: string;
  firstName: string;
  lastName: string;
}
