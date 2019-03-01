import { Injectable } from '@angular/core';
import { Apollo } from 'apollo-angular';
import gql from 'graphql-tag';
import { map } from 'rxjs/operators';

import { User } from '../../models';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(private readonly _apollo: Apollo) {}

  getUser(id: string) {
    return this._apollo
      .query<{ user: User }>({
        query: gql`
          {
            user(id: ${id}) {
              id
              name
            }
          }
        `,
      })
      .pipe(map(result => result.data.user))
      .toPromise();
  }

  getUsers() {
    return this._apollo
      .query<{ users: User[] }>({
        query: gql`
          {
            users {
              id
              name
            }
          }
        `,
      })
      .pipe(map(result => result.data.users))
      .toPromise();
  }
}
