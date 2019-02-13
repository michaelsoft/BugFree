import { AppSettings } from './appSettings';
import { User } from './user';

export class AppData {

  static appSettings: AppSettings;
  static currentUser: User;

  constructor() { }
}
