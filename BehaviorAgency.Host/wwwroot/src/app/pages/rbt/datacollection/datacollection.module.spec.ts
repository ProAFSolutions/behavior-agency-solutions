import { DatacollectionModule } from './datacollection.module';

describe('DatacollectionModule', () => {
  let datacollectionModule: DatacollectionModule;

  beforeEach(() => {
    datacollectionModule = new DatacollectionModule();
  });

  it('should create an instance', () => {
    expect(datacollectionModule).toBeTruthy();
  });
});
