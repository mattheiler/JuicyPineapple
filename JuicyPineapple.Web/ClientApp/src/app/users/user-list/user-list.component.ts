import { Component, OnInit } from '@angular/core';

import { User } from '../../models';
import { UserService } from '../shared';

@Component({
  selector: 'app-user-list',
  templateUrl: './user-list.component.html',
  styleUrls: ['./user-list.component.scss']
})
export class UserListComponent implements OnInit {

  organizations: Promise<User[]>;

  constructor(private readonly _service: UserService) {}

  ngOnInit() {
    this.organizations = this._service.getUsers();
  }

}
