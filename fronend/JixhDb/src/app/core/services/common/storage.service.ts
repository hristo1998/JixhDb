import { Injectable } from '@angular/core';

@Injectable()
export class StorageService {
  public store(key: string, value: any) {
    localStorage.setItem(key, JSON.stringify(value));
  }

  public retrieve(key: string): any {
    const json = localStorage.getItem(key);
    return json ? JSON.parse(json) : null;
  }

  public remove(key: string) {
    localStorage.removeItem(key);
  }

  public clear() {
    localStorage.clear();
  }
}
