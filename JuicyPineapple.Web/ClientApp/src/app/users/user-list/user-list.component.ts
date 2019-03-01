import { Component } from '@angular/core';

import { User } from '../../models';
import { UserService } from '../shared';

@Component({
  selector: 'app-user-list',
  templateUrl: './user-list.component.html',
  styleUrls: ['./user-list.component.scss']
})
export class UserListComponent {

  users: Promise<User[]>;

  constructor(private readonly _service: UserService) {
    this.users = this._service.getUsers();
  }

}
