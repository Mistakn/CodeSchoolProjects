<template>
  <div>
      <strong>Order Details</strong>
            <table>
                <thead>
                    <tr>
                        <th>Item</th>
                        <th>Total</th>
                    </tr>
                </thead>
                <tbody>
                    <tr v-for="item in orderItems" :key="item.name">
                        <td>{{item.quantity}}x {{item.name}}</td>
                        <td>$ {{itemTotal(item)}}</td>
                    </tr>
                    <tr v-if="orderTotal > 0">
                        <td style="border-top:1px solid">Total:</td>
                        <td style="border-top:1px solid">$ {{orderTotal}}</td>
                    </tr>
                </tbody>
            </table>
  </div>
</template>

<script>
export default {
  props: ['orderItems'],
  methods: {
    itemTotal(itemData) {
      return (itemData.quantity * itemData.price).toFixed(2);
    },
  },
  computed: {
    orderTotal() {
      let total = 0;
      if (this.orderItems.length > 0) {
        this.orderItems.forEach((item) => {
          total += parseFloat(this.itemTotal(item), 10);
        });
      }
      return total.toFixed(2);
    },
  },
};
</script>

<style>

</style>
