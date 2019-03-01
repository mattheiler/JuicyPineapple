import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { UsersRoutingModule } from './users-routing.module';

import { UserComponent } from './user';
import { UserListComponent } from './user-list';
import { UserService } from './shared';

@NgModule({
  declarations: [UserListComponent, UserComponent],
  imports: [CommonModule, UsersRoutingModule],
  providers: [UserService]
})
export class UsersModule {
}
