import { RbtModule } from './rbt.module';

describe('RbtModule', () => {
  let rbtModule: RbtModule;

  beforeEach(() => {
    rbtModule = new RbtModule();
  });

  it('should create an instance', () => {
    expect(rbtModule).toBeTruthy();
  });
});
