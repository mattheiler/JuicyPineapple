import { Injectable } from '@angular/core';
import { Apollo } from 'apollo-angular';
import gql from 'graphql-tag';
import { map } from 'rxjs/operators';

import { Organization } from '../../models';

@Injectable({
  providedIn: 'root'
})
export class OrganizationService {

  constructor(private readonly _apollo: Apollo) { }

  getOrganization(id: string) {
    return this._apollo
      .query<{ organization: Organization }>({
        query: gql`
          {
            organization(id: "${id}") {
              id
              name
            }
          }
        `,
      })
      .pipe(map(result => result.data.organization))
      .toPromise();
  }

  getOrganizations() {
    return this._apollo
      .query<{ organizations: Organization[] }>({
        query: gql`
          {
            organizations {
              id
              name
            }
          }
        `,
      })
      .pipe(map(result => result.data.organizations))
      .toPromise();
  }
}
