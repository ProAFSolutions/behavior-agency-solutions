import { AnalystModule } from './analyst.module';

describe('AnalystModule', () => {
  let analystModule: AnalystModule;

  beforeEach(() => {
    analystModule = new AnalystModule();
  });

  it('should create an instance', () => {
    expect(analystModule).toBeTruthy();
  });
});
