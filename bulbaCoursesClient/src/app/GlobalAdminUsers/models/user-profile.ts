export interface UserProfile {
  Id: string;
  GivenName: string;
  FamilyName: string;
  Email: string;
  Gender: string;
  BirthDate: string;
  PhoneNumber: string;
  Address: string;
  Picture: string;

  ProfileParams: ProfileParams [];
    // {
    //   FieldName: string,
    //   FieldValue: string,
    //   ClaimType: string
    // }]
}
export interface ProfileParams {
  FieldName: string;
  FieldValue: string;
  ClaimType: string;
}
