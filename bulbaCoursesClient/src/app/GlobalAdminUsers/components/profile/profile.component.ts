import { Component, OnInit } from '@angular/core';
import { UserProfile } from '../../models/user-profile';
import { UserService } from '../../services/user.service';
import { Router, ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.scss']
})
export class ProfileComponent implements OnInit {
  userProfile: UserProfile ;
  id: string;
  constructor(private serv: UserService,  private router: Router, route: ActivatedRoute) {
    route.params.subscribe(params => this.id = params['id'])
  }

  ngOnInit() {
    this.serv.getUserProfile(this.id).subscribe(
  data => {
    this.userProfile = data;
    console.log('userProfile Loaded');
  },
  () => console.log('Error with getting userprofile'),
  () => null
);
  }

  saveUserProfile(userProfile: UserProfile) {
    console.log("Everything is OK");//userProfile.FamilyName"");
  }

  changePassword(id: string){
      this.router.navigate(['/profile/password', id]);
  }

}
