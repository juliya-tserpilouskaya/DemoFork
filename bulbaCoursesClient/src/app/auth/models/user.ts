export interface User {
  id: string;
  // define user data here
}

export interface PresentationUser extends User {
  name: string;
}

export interface CustomUser extends User {
  sub: string;
  given_name: string;
  family_name: string;
  preferred_username: string;
}
