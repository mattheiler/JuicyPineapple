import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { UserComponent } from './user';
import { UserListComponent } from './user-list';

const routes: Routes = [
  {
    path: '',
    pathMatch: 'full',
    component: UserListComponent,
  },
  {
    path: ':id',
    pathMatch: 'full',
    component: UserComponent,
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class UsersRoutingModule { }
