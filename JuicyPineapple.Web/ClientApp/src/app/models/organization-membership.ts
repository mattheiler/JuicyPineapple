import { Organization } from './organization';
import { User } from './user';

export class OrganizationMembership {
  organization: Organization;
  organizationId: string;
  user: User;
  userId: string;
}
