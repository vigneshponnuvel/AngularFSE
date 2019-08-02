import { TestBed } from '@angular/core/testing';
import { BackendApiService } from './backend-api.service';
import { HttpClientModule } from "@angular/common/http";

describe('BackendApiService', () => {
  beforeEach(() => TestBed.configureTestingModule({ imports: [    
    HttpClientModule        
]}));

  it('should be created', () => {
    const service: BackendApiService = TestBed.get(BackendApiService);
    expect(service).toBeTruthy();
  });
});
